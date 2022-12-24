using EmlaBot.Models;
using System;
using System.Collections.Generic;

namespace EmlaBot.Services
{
    public class EmloaLock
    {
        /// <summary>
        /// This Request will return information the user and their session (if in a session).
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public InfoResponse GetInfo(IApiToken user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddTime(IApiToken wearer, TimeSpan duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractTime(IApiToken wearer, IApiToken holder, TimeSpan duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s duration by a random amount
        /// between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to add.</param>
        /// <param name="upperBound">The maximum duration to add.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddRandomTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s duration by a random amount
        /// between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to remove.</param>
        /// <param name="upperBound">The maximum duration to remove.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractRandomTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s maximum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddMaximumTime(IApiToken wearer, TimeSpan duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s maximum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractMaximumTime(IApiToken wearer, IApiToken holder, TimeSpan duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s maximum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to add.</param>
        /// <param name="upperBound">The maximum duration to add.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddRandomMaximumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s maximum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to remove.</param>
        /// <param name="upperBound">The maximum duration to remove.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractRandomMaximumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s Minimum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddMinimumTime(IApiToken wearer, TimeSpan duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s Minimum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractMinimumTime(IApiToken wearer, IApiToken holder, TimeSpan duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s Minimum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to add.</param>
        /// <param name="upperBound">The maximum duration to add.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddRandomMinimumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s Minimum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="lowerBound">The minimum duration to remove.</param>
        /// <param name="upperBound">The maximum duration to remove.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractRandomMinimumTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s number of requirement links by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The number of requirement links.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddRequirementLinks(IApiToken wearer, int duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s number of requirement links by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The number of requirement links.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse SubtractRequirementLinks(IApiToken wearer, IApiToken holder, int duration, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s number of requirement links by
        /// a random amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum number of requirement links to add.</param>
        /// <param name="upperBound">The maximum number of requirement links to add.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public InfoResponse AddRandomRequirementLinks(IApiToken wearer, int lowerBound, int upperBound, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s number of requirement links by
        /// a random amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="lowerBound">The minimum number of requirement links to remove.</param>
        /// <param name="upperBound">The maximum number of requirement links to remove.</param>
        /// <returns></returns>
        public InfoResponse SubtractRandomRequirementLinks(IApiToken wearer, IApiToken holder, int lowerBound, int upperBound)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the activity feed for the given session.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns></returns>
        public IEnumerable<AggregatedAction> GetFeed(string sessionId)
        {
            throw new NotImplementedException();
        }
    }
}