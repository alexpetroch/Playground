namespace Playground.SD
{
    /*
     Functional use cases:
         There is a dictionary and when user enters some word then it auto suggests other words
         Admin can add/remove word into dictionary
         The search is not like bu rather "begin with"
         Top suggestions

     Non-functional use cases:
         Heavy read system
         Latency should be minimal
         Eventual consistency. If admin adds word to dictionary it's ok to wait until it will be propagated into all systems
         
    Design: Shard based on first latter
            Search based on trie from replica.
            Keep CDN closer to the user

    Save frequency in each node which relates to all down phases. Keep only top phases in the node (say 5)

        Trie
    TrieNode
        keep child nodes
        Keep parent node
        keep top 5 suggestions with reference to last node. List <Count Frequency, LastNode>.
    Having last node it's possible to build word with tr aversion from leaf to parent
    
    Parent node combine top suggestions from child nodes.

    Update frequency rule: Store searches and do update every day/hour based on requirements. Update can be done with map/reduce.   
                            Update replica first and then switch it with single leader/master node.

    How to store: Serialize into file
     */
}
