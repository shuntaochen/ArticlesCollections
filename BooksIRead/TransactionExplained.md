1. Write transaction in database:
Ensure is using the same transation
2. Read transation:
Accordingly, executing multiple sql command relying on high real-time data should use transation and commit
3. Distributed transation:
> CAP principle: 

### Consistency: Must return the value after write opertion.
### Accessibility: Must reply to User request. 
### Partition tolerance: Distributed systems locate in different subnets, eg. one in US, one in China.
P is always true, C and A needs to be implemented.

A general handling state, each one is a sub transaction, state change on each done, final consistency!! My understanding.
Using MSMQ one solution: Partition-> db managed state; Then to MSMQ-> MSMQ managed; Subscribers get from queue-> db managed state!

What Ruan is saying about the principle:
[CAPExplained](http://www.ruanyifeng.com/blog/2018/07/cap.html)
[Transaction ACID](https://baike.baidu.com/item/acid/10738?fr=aladdin)
