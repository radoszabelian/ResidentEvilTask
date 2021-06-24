using ResidentEvil.BusinessLogic.GameLogic;

namespace ResidentEvil.BusinessLogic.FileHandling
{
	internal interface IFileReader
	{
		Stage DeserializeStage();
	}
}