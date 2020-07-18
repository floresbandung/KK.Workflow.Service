using System;
using System.Threading.Tasks;
using KK.Workflow.Service.DataContext;
using Microsoft.EntityFrameworkCore;
using Workflow.Shared;

namespace KK.Workflow.Service.Features
{
    public class NumberingHelper
    {
        private readonly WorkflowDataContext _dataContext;

        public NumberingHelper(WorkflowDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> NewRequestNumber()
        {
            var configurationNumber = await 
                _dataContext.ConfigurationNumbers.FirstOrDefaultAsync(c => c.Name.Equals("REQUEST_NUMBER"));
            //var a = configurationNumberManager.GetConfigurationNumber("JOURNAL_VOUCHER").ToList();
            // NOTE SINGLE CONFIG TANPA Suffix Type
            if (configurationNumber == null)
                throw new Exception(WorkflowMessage.INVALID_CONFIG_NUMBER);
            var result = (configurationNumber.LastIndex + 1).ToString("D" + configurationNumber.LengthNumber);

            // update 
            configurationNumber.LastIndex += 1;
            configurationNumber.ModifiedDate = DateTime.Now;
            await _dataContext.SaveChangesAsync();
            return result;
        }
    }
}
