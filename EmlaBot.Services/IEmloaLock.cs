using EmlaBot.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmlaBot.Services
{
    public interface IEmloaLock
    {
        Task<InfoResponse> AddMaximumTime(IApiToken wearer, TimeSpan duration);

        Task<InfoResponse> AddMinimumTime(IApiToken wearer, TimeSpan duration);

        Task<InfoResponse> AddRandomMaximumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound);

        Task<InfoResponse> AddRandomMinimumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound);

        Task<InfoResponse> AddRandomRequirementLinks(IApiToken wearer, int lowerBound, int upperBound);

        Task<InfoResponse> AddRandomTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound);

        Task<InfoResponse> AddRequirementLinks(IApiToken wearer, int duration);

        Task<InfoResponse> AddTime(IApiToken wearer, TimeSpan duration, string message);

        Task<IEnumerable<AggregatedAction>> GetFeed(string sessionId);

        Task<InfoResponse> GetInfo(IApiToken user);

        Task<InfoResponse> SubtractMaximumTime(IApiToken wearer, IApiToken holder, TimeSpan duration);

        Task<InfoResponse> SubtractMinimumTime(IApiToken wearer, IApiToken holder, TimeSpan duration);

        Task<InfoResponse> SubtractRandomMaximumTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound);

        Task<InfoResponse> SubtractRandomMinimumTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound);

        Task<InfoResponse> SubtractRandomRequirementLinks(IApiToken wearer, IApiToken holder, int lowerBound, int upperBound);

        Task<InfoResponse> SubtractRandomTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound);

        Task<InfoResponse> SubtractRequirementLinks(IApiToken wearer, IApiToken holder, int duration);

        Task<InfoResponse> SubtractTime(IApiToken wearer, IApiToken holder, TimeSpan duration, string message);
    }
}