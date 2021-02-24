using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Models;

namespace TimeTracker.Services.Statement
{
    public interface IStatementService
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
