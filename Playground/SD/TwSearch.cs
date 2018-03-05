namespace Playground.SD
{
    /*
     Functional req:
     Find words/phase in text, people. tags
     Build response page for end user

     Non-functional req:
     - We need to provide quick response / low latency
     - Highly available. Eventual consistency
     - How to aggregate response

     Use case:
     - Use enters text and click find.
     - Results are displayed on the page and sorted: users first, then in text.

     Load:
     - 1 mln active users per. Search - 10 mln queries per day -> 10mln / 3600 / 24 = 116 QPS
     - Traffic: Each query returns: 10 KBytes -> 10000 * 100 * 100 = 100 Gb per day traffic

    API:
     - Search(id-token, text, filter, numberstoreturn, page)

    Component DesignL
    - Use indexing
     
     */
}
