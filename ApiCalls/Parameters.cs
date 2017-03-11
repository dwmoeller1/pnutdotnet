using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppNetDotNet.ApiCalls
{
    public class Parameters
    {
        public string since_id { get; set; }
        public string before_id { get; set; }
        public int count { get; set; }
        public bool include_muted { get; set; }
        private string _include_muted
        {
            get
            {
                if (include_muted)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        public bool include_deleted { get; set; }
        private string _include_deleted
        {
            get
            {
                if (include_deleted)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        public bool include_directed_posts { get; set; }
        private string _include_directed_posts
        {
            get
            {
                if (include_directed_posts)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        public bool include_raw { get; set; }
        private string _include_raw
        {
            get
            {
                if (include_raw)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        public bool include_bookmarked_by { get; set; }
        private string _include_bookmarked_by
        {
            get
            {
                if (include_bookmarked_by)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        public bool include_reposted_by { get; set; }
        private string _include_reposted_by
        {
            get
            {
                if (include_reposted_by)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }
        public bool include_user_as_id { get; set; }
        private string _include_user_as_id
        {
            get
            {
                if (include_user_as_id)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
        }

        public Parameters()
        {
            since_id = "";
            before_id = "";
            count = 0;
            // except on request for muted user
            include_muted = false;
            include_deleted = true;
            // except on "My stream"
            include_directed_posts = true;
            include_raw = false;
            include_bookmarked_by = false;
            include_reposted_by = false;
            include_user_as_id = false;
        }

        public string getQueryString()
        {
            string queryString = "";
            if (!string.IsNullOrEmpty(since_id))
            {
                queryString += "since_id=" + since_id + "&";
            }
            if (!string.IsNullOrEmpty(before_id))
            {
                queryString += "before_id=" + before_id + "&";
            }
            if (count != 0)
            {
                queryString += "count=" + count.ToString() + "&";
            }
            queryString += string.Format("include_muted={0}&include_deleted={1}&include_directed_posts={2}&include_raw={3}&include_bookmarked_by={4}&include_reposted_by={5}&include_user_as_id={6}", 
                _include_muted,
                _include_deleted,
                _include_directed_posts,
                _include_raw,
                _include_bookmarked_by,
                _include_reposted_by,
                _include_user_as_id);
            return queryString;
        }
    }

    public class ParametersMyStream : Parameters
    {
        public ParametersMyStream()
        {
            include_directed_posts = false;
        }
    }
    public class ParametersMutedUsersRequest : Parameters
    {
        public ParametersMutedUsersRequest()
        {
            include_muted = true;
        }
    }

}
