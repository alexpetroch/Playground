namespace Playground.SD
{
   /*
    Functional requirements:
    - User can post a tweet
    - User can subscribe on users
    - User can see tweets from subscribed users
    - Tweets can have photo or video content
    
    Non-functional requirements:
    - We need to provide min latency as we can. 
    - The system should have high availability
    - System could be eventually consistent
    - System will have much more reads than writes from subscribed users
    - System should maintain with of web/mobile clients
    - 1 Tweet size is 250 chars/500 bytes
    - Each users has 100 followers

    Extended non-functional requirements:
    - Search tweets
    - Search users

    Load:
    - 1 mln active users per day
    - 100K tweets every day -> 10000 / 24 / 3600 = 2 tweets per sec
    - 200 tweets read per sec

    Storage capacity:
    - Keep 5 years: 100k * 365 * 5 * 500B = 36Mln * 5 * 500B = 160Mln * 500B = 80Gb

    API:
    - postTweet (userId, content, location, media_ids) / token is required

    High level:

     
   */
}
