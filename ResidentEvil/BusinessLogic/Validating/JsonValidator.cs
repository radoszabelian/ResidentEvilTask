using ResidentEvil.BusinessLogic.FileHandling.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ResidentEvil.BusinessLogic.Validating
{
	internal class JsonValidator
	{
		public void ValidateAll(AllJson all)
		{
			ValidateAttributes(all.Stage);
			ValidateAttributes(all.Player);
			ValidateAttributes(all.Enemies.AsEnumerable());
		}

		private void ValidateAttributes<T>(IEnumerable<T> objects)
		{
			foreach (var obj in objects)
				ValidateAttributes(obj);
		}

		private void ValidateAttributes<T>(T obj)
		{
			ValidateProperies(obj, typeof(RequiredAttribute));
			ValidateProperies(obj, typeof(RangeAttribute));
			ValidateProperies(obj, typeof(RegularExpressionAttribute));
			ValidateProperies(obj, typeof(CustomAttributeData));
		}

		private void ValidateProperies<T>(T obj, Type attributeType)
		{
			var properites = new Validator<T>()[attributeType];

			foreach (var property in properites)
			{
				var attribute = (ValidationAttribute)property.GetCustomAttributes(attributeType, false).First();
				attribute.Validate(property.GetValue(obj), property.Name.ToLower());
			}
		}

		private class Validator<TObj>
		{
			private static Dictionary<Type, PropertyInfo[]> dictionary =
				new Dictionary<Type, PropertyInfo[]>();

			public PropertyInfo[] this[Type attributeType]
			{
				get
				{
					if (!dictionary.ContainsKey(attributeType))
						return new PropertyInfo[0];

					return dictionary[attributeType];
				}
			}

			static Validator()
			{
				var attributes = new[] { typeof(RequiredAttribute), typeof(RangeAttribute), typeof(RegularExpressionAttribute), typeof(CustomValidationAttribute) };
				var properties = typeof(TObj).GetProperties();

				foreach (var attribute in attributes)
				{
					var attributeProperties = properties.SelectMany(p => p.GetCustomAttributes(attribute)
														.Select(a => p)
														.Distinct())
														.ToArray();


					dictionary.Add(attribute, attributeProperties);
				}
			}
		}
	}
}
