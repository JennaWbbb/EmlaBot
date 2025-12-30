using EmlaBot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml;

namespace EmlaBot.Services
{
    /// <summary>
    /// </summary>
    /// <seealso cref="EmlaBot.Services.IEmlaLock" />
    public class EmlaLock : IEmlaLock
    {
        private readonly IEmlaLockConfig _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public EmlaLock(IEmlaLockConfig config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// This Request will return information the user and their session (if in a session).
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> GetInfo(IApiToken user)
        {
            return user == null
                ? throw new ArgumentNullException(nameof(user))
                : GetResponse(new Uri(_config.BaseUrl, $"info?userid={Uri.EscapeDataString(user.UserId.Trim())}&apikey={Uri.EscapeDataString(user.ApiKey.Trim())}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<InfoResponse> AddTime(IApiToken wearer, TimeSpan duration, string message)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int val = (int)Math.Abs(duration.TotalSeconds);
            string msg = !string.IsNullOrWhiteSpace(message) ? $"&text={Uri.EscapeDataString(message)}" : string.Empty;

            return GetResponse(new Uri(_config.BaseUrl, $"add?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&value={val}{msg}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <remarks>
        /// Must be called with the holder's key. Naive attempts of reducing your own time will be
        /// penalised 😘
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractTime(IApiToken wearer, IApiToken holder, TimeSpan duration, string message)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddTime(wearer, duration, message);
            }

            int val = (int)Math.Abs(duration.TotalSeconds);
            string msg = !string.IsNullOrWhiteSpace(message) ? $"&text={Uri.EscapeDataString(message)}" : string.Empty;

            return GetResponse(new Uri(_config.BaseUrl, $"sub?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&value={val}{msg}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s duration by a random amount
        /// between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to add.</param>
        /// <param name="upperBound">The maximum duration to add.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddRandomTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int from = (int)Math.Abs(lowerBound.TotalSeconds);
            int to = (int)Math.Abs(upperBound.TotalSeconds);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"addrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&from={from}&to={to}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s duration by a random amount
        /// between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to remove.</param>
        /// <param name="upperBound">The maximum duration to remove.</param>
        /// <returns></returns>
        /// <remarks>
        /// Must be called with the holder's key. Naive attempts of reducing your own time will be
        /// penalised 😘
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractRandomTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddRandomTime(wearer, lowerBound, upperBound);
            }

            int from = (int)Math.Abs(lowerBound.TotalSeconds);
            int to = (int)Math.Abs(upperBound.TotalSeconds);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"subrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&from={from}&to={to}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s maximum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddMaximumTime(IApiToken wearer, TimeSpan duration)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int val = (int)Math.Abs(duration.TotalSeconds);

            return GetResponse(new Uri(_config.BaseUrl, $"addmaximum?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&value={val}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s maximum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractMaximumTime(IApiToken wearer, IApiToken holder, TimeSpan duration)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddMaximumTime(wearer, duration);
            }

            int val = (int)Math.Abs(duration.TotalSeconds);

            return GetResponse(new Uri(_config.BaseUrl, $"submaximum?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&value={val}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s maximum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to add.</param>
        /// <param name="upperBound">The maximum duration to add.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddRandomMaximumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int from = (int)Math.Abs(lowerBound.TotalSeconds);
            int to = (int)Math.Abs(upperBound.TotalSeconds);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"addmaximumrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&from={from}&to={to}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s maximum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to remove.</param>
        /// <param name="upperBound">The maximum duration to remove.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractRandomMaximumTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddRandomMaximumTime(wearer, lowerBound, upperBound);
            }

            int from = (int)Math.Abs(lowerBound.TotalSeconds);
            int to = (int)Math.Abs(upperBound.TotalSeconds);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"submaximumrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&from={from}&to={to}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s Minimum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddMinimumTime(IApiToken wearer, TimeSpan duration)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int val = (int)Math.Abs(duration.TotalSeconds);

            return GetResponse(new Uri(_config.BaseUrl, $"addminimum?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&value={val}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s Minimum duration by <paramref name="duration" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="duration">The duration.</param>
        /// <returns></returns>
        public Task<InfoResponse> SubtractMinimumTime(IApiToken wearer, IApiToken holder, TimeSpan duration)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddMinimumTime(wearer, duration);
            }

            int val = (int)Math.Abs(duration.TotalSeconds);

            return GetResponse(new Uri(_config.BaseUrl, $"subminimum?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&value={val}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s Minimum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum duration to add.</param>
        /// <param name="upperBound">The maximum duration to add.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddRandomMinimumTime(IApiToken wearer, TimeSpan lowerBound, TimeSpan upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int from = (int)Math.Abs(lowerBound.TotalSeconds);
            int to = (int)Math.Abs(upperBound.TotalSeconds);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"addminimumrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&from={from}&to={to}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s Minimum duration by a random
        /// amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="holder">The holder.</param>
        /// <param name="lowerBound">The minimum duration to remove.</param>
        /// <param name="upperBound">The maximum duration to remove.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractRandomMinimumTime(IApiToken wearer, IApiToken holder, TimeSpan lowerBound, TimeSpan upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddRandomMinimumTime(wearer, lowerBound, upperBound);
            }

            int from = (int)Math.Abs(lowerBound.TotalSeconds);
            int to = (int)Math.Abs(upperBound.TotalSeconds);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"subminimumrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&from={from}&to={to}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s number of requirement links by <paramref name="quantity" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="quantity">The number of requirement links.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddRequirementLinks(IApiToken wearer, int quantity)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int val = Math.Abs(quantity);

            return GetResponse(new Uri(_config.BaseUrl, $"addrequirement?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&value={val}"));
        }

        /// <summary>
        /// This Request will reduce the <paramref name="wearer" />'s number of requirement links by <paramref name="quantity" />
        /// </summary>
        /// <param name="wearer"></param>
        /// <param name="holder"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractRequirementLinks(IApiToken wearer, IApiToken holder, int quantity)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddRequirementLinks(wearer, quantity);
            }

            int val = Math.Abs(quantity);

            return GetResponse(new Uri(_config.BaseUrl, $"subrequirement?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&value={val}"));
        }

        /// <summary>
        /// This Request will raise the <paramref name="wearer" />'s number of requirement links by
        /// a random amount between <paramref name="lowerBound" /> and <paramref name="upperBound" />
        /// </summary>
        /// <param name="wearer">The wearer.</param>
        /// <param name="lowerBound">The minimum number of requirement links to add.</param>
        /// <param name="upperBound">The maximum number of requirement links to add.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> AddRandomRequirementLinks(IApiToken wearer, int lowerBound, int upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            int from = Math.Abs(lowerBound);
            int to = Math.Abs(upperBound);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"addrequirementrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&from={from}&to={to}"));
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
        /// <exception cref="ArgumentNullException">
        /// Thrown if no <paramref name="wearer" /> is provided
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="wearer" /> is missing its user id or API key
        /// </exception>
        public Task<InfoResponse> SubtractRandomRequirementLinks(IApiToken wearer, IApiToken holder, int lowerBound, int upperBound)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                return AddRandomRequirementLinks(wearer, lowerBound, upperBound);
            }

            int from = Math.Abs(lowerBound);
            int to = Math.Abs(upperBound);

            if (to > from)
            {
                (from, to) = (to, from);
            }

            return GetResponse(new Uri(_config.BaseUrl, $"subrequirementrandom?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}&holderapikey={holder.ApiKey.Trim()}&from={from}&to={to}"));
        }

        /// <summary>
        /// Retrieves the current Locktober statistics.
        /// </summary>
        /// <returns>
        /// The task result contains a <see cref="LocktoberStats"/> object with the latest Locktober statistics.
        /// </returns>
        public async Task<LocktoberStats> GetLocktoberStats()
        {
            return await GetResponse<LocktoberStats>(new Uri(_config.BaseUrl, "locktober"));
        }

        /// <summary>
        /// Retrieves the action feed for a specified wearer, optionally filtered by a holder's credentials.
        /// </summary>
        /// <remarks>If the holder parameter is provided and its API key differs from the wearer's, the
        /// feed is filtered using the holder's credentials. Otherwise, the feed is retrieved for the wearer
        /// only.</remarks>
        /// <param name="wearer">The API token representing the wearer whose action feed is to be retrieved. Cannot be null and must contain
        /// valid user ID and API key.</param>
        /// <param name="holder">The API token representing the holder whose credentials may be used to filter the feed. If null or if the
        /// API key matches the wearer's, the feed is retrieved without holder filtering.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of action items for
        /// the specified wearer. The collection will be empty if no actions are available.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the wearer parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the wearer parameter does not contain valid API credentials.</exception>
        public async Task<IEnumerable<ActionItem>> GetFeed(IApiToken wearer, IApiToken holder)
        {
            if (wearer == null)
            {
                throw new ArgumentNullException(nameof(wearer));
            }

            if (string.IsNullOrWhiteSpace(wearer.UserId) || string.IsNullOrWhiteSpace(wearer.ApiKey))
            {
                throw new ArgumentOutOfRangeException(nameof(wearer), "Missing wearer API credentials");
            }

            IEnumerable<ActionItem> results;

            if (holder == null || string.IsNullOrWhiteSpace(holder.ApiKey) || string.Equals(wearer.ApiKey, holder.ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                //https://api.emlalock.com/sessionfeed?apikey=g7288qnyk7&userid=4wx7wa1ur1v6r03
                results = await GetResponse<IEnumerable<ActionItem>>(new Uri(_config.BaseUrl, $"sessionfeed?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(wearer.ApiKey.Trim())}"));
            }
            else
            {
                //https://api.emlalock.com/sessionfeed?userid=j2k62iogvm6y6pm&apikey=g7288qnyk7&holderid=4wx7wa1ur1v6r03
                results = await GetResponse<IEnumerable<ActionItem>>(new Uri(_config.BaseUrl, $"sessionfeed?userid={Uri.EscapeDataString(wearer.UserId.Trim())}&apikey={Uri.EscapeDataString(holder.ApiKey.Trim())}&holderid={Uri.EscapeDataString(holder.UserId.Trim())}"));
            }

            return results.ToList();
        }

        /// <summary>
        /// Gets the activity feed for the given session.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns></returns>
        public async IAsyncEnumerable<AggregatedAction> GetFeed(string sessionId)
        {
            var xml = await GetFeedXml(sessionId);

            foreach( var item in xml.SelectNodes("/rss/channel/item").OfType<XmlElement>())
            {
                var title = item.SelectSingleNode("title")?.InnerText;
                var pubDate = item.SelectSingleNode("pubDate")?.InnerText;
                // might be easier to parse the guid for a timestamp?

                yield return ParseRssTitle(title, pubDate);
            }
        }

        /// <summary>
        /// Parses the RSS title and publication date into an AggregatedAction object.
        /// </summary>
        /// <param name="title">The title of the RSS item.</param>
        /// <param name="pubDate">The publication date of the RSS item.</param>
        /// <returns>An AggregatedAction object containing the parsed data.</returns>
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public AggregatedAction ParseRssTitle(string title, string pubDate)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (string.IsNullOrEmpty(pubDate) || !DateTime.TryParse(pubDate, out DateTime eventDate))
            {
                throw new FormatException(pubDate);
            }

            // TODO: need to work stuff out here ofr durations, when not hidden, as well as actiom

            return new AggregatedAction
            {
                Time = eventDate.ToUnixTimestamp(),
            };
        }

        /// <summary>
        /// Gets the feed XML for the given session.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the XML document.</returns>
        public async Task<XmlDocument> GetFeedXml(string sessionId)
        {
            var _emlaClient = _httpClientFactory.CreateClient();
            var httpResponse = await _emlaClient.GetAsync(new Uri(_config.BaseUrl, $"rssfeed?chastitysessionid={Uri.EscapeDataString(sessionId.Trim())}"));
            if (httpResponse.IsSuccessStatusCode)
            {
                var doc = new XmlDocument();
                doc.LoadXml(await httpResponse.Content.ReadAsStringAsync());
                return doc;
            }
            else
            {
                if (httpResponse.StatusCode == (HttpStatusCode)429)
                {
                    throw new RateLimitedException(await httpResponse.Content.ReadAsStringAsync());
                }
                else if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidApiKeyException(await httpResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    // TOOD: This needs to be way better
                    throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
                }
            }
        }

        /// <summary>
        /// Gets the response from the API and deserializes the response.
        /// </summary>
        /// <param name="uri">The URI of the resource to request. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the InfoResponse object.</returns>
        /// <exception cref="RateLimitedException">Thrown when the server responds with a status code indicating too many requests (HTTP 429).</exception>
        /// <exception cref="InvalidApiKeyException">Thrown when the server responds with a status code indicating an invalid API key (HTTP 400).</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request fails for reasons other than rate limiting or invalid API key.</exception>
        public async Task<InfoResponse> GetResponse(Uri uri)
        {
            return await GetResponse<InfoResponse>(uri);
        }

        /// <summary>
        /// Sends an HTTP GET request to the specified URI and deserializes the JSON response into an object of type T.
        /// </summary>
        /// <remarks>The response content is expected to be in JSON format and compatible with the
        /// specified type T. The method uses a new HTTP client instance for each request. Callers should ensure that
        /// the provided URI is valid and accessible.</remarks>
        /// <typeparam name="T">The type into which the JSON response is deserialized. Must be compatible with the response schema.</typeparam>
        /// <param name="uri">The URI of the resource to request. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response object
        /// of type T.</returns>
        /// <exception cref="RateLimitedException">Thrown when the server responds with a status code indicating too many requests (HTTP 429).</exception>
        /// <exception cref="InvalidApiKeyException">Thrown when the server responds with a status code indicating an invalid API key (HTTP 400).</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request fails for reasons other than rate limiting or invalid API key.</exception>
        public async Task<T> GetResponse<T>(Uri uri)
        {
            var _emlaClient = _httpClientFactory.CreateClient();
            var httpResponse = await _emlaClient.GetAsync(uri);
            if (httpResponse.IsSuccessStatusCode)
            {
                using var str = await httpResponse.Content.ReadAsStreamAsync();
                var ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(str);
            }
            else
            {
                if (httpResponse.StatusCode == (HttpStatusCode)429)
                {
                    throw new RateLimitedException(await httpResponse.Content.ReadAsStringAsync());
                }
                else if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidApiKeyException(await httpResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    // TOOD: This needs to be way better
                    throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
                }
            }
        }
    }
}