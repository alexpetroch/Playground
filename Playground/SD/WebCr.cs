

/*
    Web Crawler:

What content we need to search?

- Functional Requirements:
 a) start from url and go through all possible url.Update with ranking?
b) monitor sites when the content changes
 c) build index for search content


 Non functional requirements
 a) Scalability: many servers research
 b) Availability
 c) Could be extensible.i.e when a new page is researches can be some features added


Storage
10bln pages * 100KB each page = 1Tb

Logic:
BFS approach.Set page as visit and put its links to unvisited queue.

Design: DNS Resolver (local DNS cache) - Http Fetcher(Store to Db)- Content Receiving - Content duplication removal - 	
                                                                                         Content Extractor
                                                                                         */
