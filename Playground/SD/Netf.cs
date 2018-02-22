namespace Playground.SD
{
    /*
     Users can upload, view, search video 
     Functional req:
        - Users can upload video
        - Users can share video with others
        - Users can seach video
        - Users can stop/pause watching video
        
     Non-functional req:
        - System should be highly available
        - Reading/Playing content id dominant
        - Latency minimal
        - Content type: streaming, a set of bytes.
        - Count of actively connected users : 1 million
        - Restore uploading / chunks
        - Eventually consistent 

    Extended req:
    - Recommendation system, user statistics.

    Load:
    - 10 mln users. Each watch 3 video per day. : 10000000 * 3 / 24 * 3600 = 350 video per sec
    - Watch/Upload ratio: 100:1 -> upload 3.5 per sec

    Storage:
    - Each video ~ 10Mb and stores for 10 years -> 10Mb * 3.5 * 86400per day * 365 * 10 = 350Mb * 86400 * 365 ~ 11 PTb

    API:
    - UploadVideo (token, video title, tags[], video content)
    - SeachVideo(token, title, description, tags[], sorted order, count of video to return)

    High-level approach:

    Client (mobile)        ->                    Read API   -> Read from cache -> Async -> Read from db replica
                           ->  Load Balancer ->  Search API -> Read from cache -> Async -> Read from storage + metadata db
    Client (traditional)   ->                    Upload API -> Put into queue -> Take from queue -> Upload into block storage + meta data 

    Distributed file storage : HDFS

     */
}
