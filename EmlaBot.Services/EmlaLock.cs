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
        /// <param name="uri">The URI.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the InfoResponse object.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<InfoResponse> GetResponse(Uri uri)
        {
            var _emlaClient = _httpClientFactory.CreateClient();
            var httpResponse = await _emlaClient.GetAsync(uri);
            if (httpResponse.IsSuccessStatusCode)
            {
                using var str = await httpResponse.Content.ReadAsStreamAsync();
                var ser = new DataContractJsonSerializer(typeof(InfoResponse));
                return (InfoResponse)ser.ReadObject(str);
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