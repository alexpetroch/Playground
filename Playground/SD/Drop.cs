namespace Playground.SD
{
    /*
     Functional req:
      - Authentification
      - Can upload file to storage
      - Can download file to local space
      - Share file with someone
      - Set visibility for the file (personal, group of users)
      - Files uploaded/synced between devices for particular user
      - Files can be edited offline and then synchronized 

     Non-funtional requirements:
      - Consistency - no data lost
      - Interface for different apps
      - Limit file to upload: 1Gb
      - ACID storage 
      - File compression
      - Sync/Notification service
     
    Extended:
      - Monitoring, logging, Analitics  
      
    Load: 
      - Heavy storage system
      - Read/Write ratio almost the same
      - Files uploaded in chunks - 8Mb
      - Count of users: 100Mln, 
      - Count of active users: 1Mln
      - Users uploads 100K files per day
      - Users read 100K files per day
      - QPS for write: 2 request per sec
      - QPS for read: 2 request per sec

    Storage load:
      - Keep files 10 year: 
      - 100K files per day * 100Mb * 365 * 10 = 365Gb * 1000 * 100 = 365Tb * 100 = 37Pb
    
    Channel traffic/Bandwidth:
      - 100K file * ~100Mb = 1000 * 100 * 100Mb = 100 Gb for read/write

    High Level:
    a. Client (Watcher, Sync, Chunk, Local Storage services)
    b. Server services: Auth, File Upload/Read, Db Metadata, Sync services
    c. Message Queue for chunks, sync, db metadata service
    d. Storage -> Sql approach since ACID in requirements 



     */
}
