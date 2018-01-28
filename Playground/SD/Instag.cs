namespace Playground.SD
{
    /*
     Functional use cases:
        - User can upload/view photos
        - User can perform search based on photo titles
        - User's photo is sharing with followers
        - Followers can see the user's photo based on recent order

    Non - functional requirements: 
        - Highly available
        - Size photo to upload: 5Mb
        - Low latency as much as we can support
        - System should prevent data loss. if a user doesn’t see a photo for a while, it should be fine.
        - Count of followers for the end user: 1000
        - Reading/Write ratio 50:1. 
        - The system is heavy reading
    
    Extended req:
        - Logging, Monitoring, Reporting
        - Analytics

    Load consideration:         
        -   Count of users 100Mln. Active users 1 mln
        -   Users upload 100K photos per day
        -   Reading/Write ratio 50:1. 
        -   100K / 24 / 3600 ~ 2 QPS for write
        -   100K * 50 / 24 / 3600 ~ 100 QPS for read
     
    Storage consideration:
        -   Keep photos for 5 years
        -   100K * 5Mb * 30 * 5 = 750Mb * 100K = 750Tb

    Channel traffic min:
          - 2 per sec * 5Mb ~ 10Mb per sec 
          - 100 per sec * 5Mb ~ 500Mb per sec

    Db schema: 
        Users: id, name, createdDate, lastLogin, hash
        Photo: id, userId, uploaded, title, blobReference
        Followers: userId, followerId, linkCreated

        Photos in distributed file system
            a) Shard by UserId (let have 100 shards and for each photo append userId as 64 bytes)
            b) Shard by PhotoId. Since we need to provide photos then it would be better choice

    High Level:
                Read Service -> Cache -> Db
    Client ->   write Service -> Async -> Db

     */
}
