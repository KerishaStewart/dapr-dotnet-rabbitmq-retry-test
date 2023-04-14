# Dapr runtime 1.10.5
### Retries Working and put on Dead Letter Queue successfully

# Commands Used
## Subscriber
dapr run -a checkout --app-port 6046 -d ..\components_rabbitmq\ -- dotnet run
## Publisher
dapr run -a orderprocessing -H 3500 -d ..\components_rabbitmq\  -- dotnet run

## docker rabbit mq
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

# Notes
Explicit declarations of the Dead Letter Topic did not work... for example:
```
    [Topic("pubsub", "newOrder", "ordersdlq", false)]
    [HttpPost("/newcheckout")]
```
But this worked:
```
    [Topic("pubsub", "newOrder")]
    [HttpPost("/newcheckout")]
```
Dapr handled the creation of the Dead Letter Topic (dlx-{{appId}}-{{topic}}) and by defalut the Dead Letter Queue(dlq-{{appId}}-{{topic}}) once the pubsub config had the setting `enableDeadLetter` set to `true`

### Flow:
Send a message to sub, sub returns HTTP status 500, message is retried n times as declared in retry policy... then the message is put on the Dead Letter Queue of format: dlq-{appId}-{topic}