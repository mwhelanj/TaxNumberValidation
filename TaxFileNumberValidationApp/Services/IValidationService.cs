using System.Threading.Tasks;

namespace TaxFileNumberValidationApp
{
    public interface IValidationService
    {
        bool ValidateTFN(string tfn);
    }
}