namespace Playground.SD
{
    /*
        Functional use-cases:
        - User can enter text and get URL
        - User can enter URL and get text

        - User can update text keeping the same URL (?)
        - User can remove "URL" and text accordingly  -timeout

       Non - functional use-cases:
        - Availability over Consistency
        - System should prevent data lost
        - Minimal latency for reading
        - Max text length: 1024 Kb symbols
        - Picture/Video not supported
        - Hard timeout exist in case user don't define

       Extended functionality cases:
        - Logging, Monitoring, Reporting
        - Analytics

       Metrics / Work load:
        - More writes than reads: 10 : 1
        - Writes per month: 10 mln
           a) Write Requests 10 mln / 30 / 24 / 3600 = ~ 4 QPS 
           b) Read Requests 10 mln * 10 / 30 / 24 / 3600 = ~ 40 QPS 

       Storage metric:
       - Max upload: 10 mln * 1024Kb = 1Gb per month
             max time to keep 1 year : 12Gb storage

       Bandwidth estimates:
          - 4 per sec * 1024Kb ~ 4kB per sec

       Memory cache:
           - 20% of traffic to cache.
           100 mln requests to read per month * 0.2 * 1Kb = 20mln * 1Kb = 20Gb for month
        */
}
