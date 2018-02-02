namespace Playground.SD
{
    /*
    Functional requirement:
      User select friend and send a message.
      The other user can see the message and reply
      Users can invite more users to the topic.
      Users can attach file to message
      User can have other conversations
      Conversation is archived and can notify user in case a new message
      Off-line/On-line status

    Non-Functional requirements:
      Latency should be minimal
      Messages should not be lost, should be int order. 
      System should prevent data loss. if a user doesn’t see a message immediately, it should be fine.

    Extended req:
      Monitoring, auto scaling, analytics
      Push notifications

    Load:
      10 mln active users per day
      Each user sends 20 messages
      Total 200 mln messages per day

    Data Storage:
      Message ~ 100 bytes
      200 mln * 100 bytes = 20 mln * 1 Kb = 20 Gb per day
      Say during 3 yers = 20 * 3 * 365 = 22000 Gb = 22 Tb

      Bandwidth: 20 Gb per day = 20 / 24 / 3600 = ~ 0.2Mb/sec

    High-Level:

    Partition based on user id to keep all messages in one particion:
    */

}
