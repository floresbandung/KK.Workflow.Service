using Workflow.Shared;

namespace KK.Workflow.Service.Features
{
    public class Helper
    {
    }
    public static class WorkflowStringExtension
    {

        public static string PopulateTemplate(this string value, string requestNumber, string username, ActionTypeEnum actionTypeEnum, string documentNumber)
        {
            return value.Replace("[TicketNumber]", requestNumber)
                .Replace("[UserName]", username)
                .Replace("[ActionName]", actionTypeEnum.ToString())
                .Replace("[DocumentNumber]", documentNumber);
        }

    }
}
