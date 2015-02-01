using jaytwo.Common.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace jaytwo.Common.Extensions
{
    public static partial class UriExtensions
    {
        public static Uri CombineWith(this Uri uri, string path)
        {
            return UrlHelper.Combine(uri, path);
        }

        public static Uri CombineWith(this Uri uri, params string[] pathSegments)
        {
            return UrlHelper.Combine(uri, pathSegments);
        }

        public static Uri CombineWith(this Uri uri, Uri pathUri)
        {
            return UrlHelper.Combine(uri, pathUri);
        }

        public static Uri Copy(this Uri uri)
        {
            return UrlHelper.CopyUri(uri);
        }

        public static string GetFileNameAndQuery(this Uri uri)
        {
            return UrlHelper.GetFileNameAndQuery(uri);
        }

        public static string GetFileNameWithoutQuery(this Uri uri)
        {
            return UrlHelper.GetFileNameWithoutQuery(uri);
        }

        public static string GetQuery(this Uri uri)
        {
            return UrlHelper.GetQueryFromUri(uri);
        }

        public static NameValueCollection GetQueryAsNameValueCollection(this Uri uri)
        {
            return UrlHelper.GetQueryFromUriAsNameValueCollection(uri);
        }

        public static string GetQueryStringParameter(this Uri uri, string key)
        {
            return UrlHelper.GetQueryStringParameterFromUri(uri, key);
        }

        public static Uri WithoutQueryStringParameter(this Uri uri, string key)
        {
            return UrlHelper.RemoveUriQueryStringParameter(uri, key);
        }

        public static Uri WithHost(this Uri uri, string newHost)
        {
            return UrlHelper.SetUriHost(uri, newHost);
        }

        public static Uri WithHost(this Uri uri, string newHost, int? newPort)
        {
            return UrlHelper.SetUriHost(uri, newHost, newPort);
        }

        public static Uri WithPort(this Uri uri, int? newPort)
        {
            return UrlHelper.SetUriPort(uri, newPort);
        }

        public static Uri WithPortHttp(this Uri uri)
        {
            return UrlHelper.SetUriPortHttp(uri);
        }

        public static Uri WithPortHttps(this Uri uri)
        {
            return UrlHelper.SetUriPortHttps(uri);
        }

        public static Uri WithPortDefault(this Uri uri)
        {
            return UrlHelper.SetUriPortDefault(uri);
        }

        public static Uri WithQuery(this Uri uri, NameValueCollection queryStringData)
        {
            return UrlHelper.SetUriQuery(uri, queryStringData);
        }

        public static Uri WithQueryStringParameter<T>(this Uri uri, string key, T value)
        {
            return UrlHelper.SetUriQueryStringParameter<T>(uri, key, value);
        }

        public static Uri WithQueryStringParameter(this Uri uri, string key, object value)
        {
            return UrlHelper.SetUriQueryStringParameter(uri, key, value);
        }

        public static Uri WithQueryStringParameter(this Uri uri, string key, string value)
        {
            return UrlHelper.SetUriQueryStringParameter(uri, key, value);
        }

        public static Uri WithScheme(this Uri uri, string newScheme)
        {
            return UrlHelper.SetUriScheme(uri, newScheme);
        }

        public static Uri WithSchemeHttp(this Uri uri)
        {
            return UrlHelper.SetUriSchemeHttp(uri);
        }

        public static Uri WithSchemeHttps(this Uri uri)
        {
            return UrlHelper.SetUriSchemeHttps(uri);
        }

        public static Uri WithoutFileNameAndQuery(this Uri uri)
        {
            return UrlHelper.GetUriWithoutFileNameAndQuery(uri);
        }

        public static Uri WithoutQuery(this Uri uri)
        {
            return UrlHelper.GetUriWithoutQuery(uri);
        }
    }
}