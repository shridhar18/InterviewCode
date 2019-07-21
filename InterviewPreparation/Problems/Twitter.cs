using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class Twitter
    {
        public int maxUserid;
        public Dictionary<int, User> userMap;

        public Twitter()
        {
            this.maxUserid = 1;
            this.userMap = new Dictionary<int, User>();
        }
        
        public int getMaxUserid()
        {
            return this.maxUserid++;
        }

        private User getUser(int uid)
        {
            if (!this.userMap.ContainsKey(uid))
            {
                User u = new User(uid);
                this.userMap.Add(uid, u);
            }

            return this.userMap[uid];
        }

        public void postTweet(int uid, int tid)
        {
            this.getUser(uid).post(tid);
        }

        public void follow(int followerId, int followeeId)
        {
            this.getUser(followerId).followed.Add(this.getUser(followeeId).uId);
        }

        public void unFollow(int followerId, int followeeId)
        {
            this.getUser(followerId).followed.Remove(followeeId);
        }

        public SortedSet<Tweet> getNewsFeed(int uid)
        {
            if (!this.userMap.ContainsKey(uid)) return null;
            //SortedSet<int> feed = new SortedSet<int>();
            SortedSet<Tweet> feed = new SortedSet<Tweet>(new TweetTimeComparar());

            foreach (int u in this.userMap[uid].followed)
            {
                if (this.userMap[u].tweetHead != null)
                {
                    Tweet t = this.userMap[u].tweetHead;
                    int i = 0;
                    while (t != null && i < 10)
                    {
                        feed.Add(t);
                        t = t.next;
                        i++;
                    }
                }
            }

            foreach (Tweet t in feed)
            {
                Console.Write(t.tId + ", ");
            }

            return feed;
        }
    }

    public class Tweet 
    {
        public int tId;
        public DateTime time;
        public Tweet next;

        public Tweet(int id)
        {
            this.tId = id;
            this.time = DateTime.Now;
            this.next = null;
        }
    }

    public class User
    {
        public int uId;
        public List<int> followed;
        public Tweet tweetHead;

        public User(int id)
        {
            this.uId = id;
            this.followed = new List<int>();
            this.followed.Add(id);
            this.tweetHead = null;
        }

        public void post(int id)
        {
            Tweet t = new Tweet(id);
            t.next = tweetHead;
            this.tweetHead = t;
        }

        public void follow(int id)
        {
            this.followed.Add(id);
        }

        public void unFollow(int id)
        {
            this.followed.Remove(id);
        }
    }

    class TweetTimeComparar : IComparer<Tweet>
    {
        public int Compare(Tweet x, Tweet y)
        {
            return x.time.CompareTo(y.time);
            //return 1;
        }
    }
}
