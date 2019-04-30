1. Write transaction in database:
Ensure is using the same transation
2. Read transation:
Accordingly, executing multiple sql command relying on high real-time data should use transation and commit
3. Distributed transation:
CAP principle: Consistency, Accessibility, Partition tolerance:
A general handling state, each one is a sub transaction, state change on each done, final consistency!! My understanding.
Using MSMQ one solution: Partition-> db managed state; Then to MSMQ-> MSMQ managed; Subscribers get from queue-> db managed state!
