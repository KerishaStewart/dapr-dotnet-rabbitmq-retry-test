# Commands Used
## Subscriber
dapr run -a checkout --app-port 6046 -d ..\components_rabbitmq\ -- dotnet run
## Publisher
dapr run -a orderprocessing -H 3500 -d ..\components_rabbitmq\ -- dotnet run
## docker rabbit mq
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

## What Subscriber Returns
== APP == Subscriber triggered...
== APP == Subscriber received : Shirt-B
time="2023-04-13T23:38:35.7248234-04:00" level=warning msg="retriable error returned from app while processing pub/sub event e63232d1-c707-44f6-868b-639d6663ca83, topic: newOrder, body: {\"type\":\"https://tools.ietf.org/html/rfc7231#section-6.6.1\",\"title\":\"An error occurred while processing your request.\",\"status\":500,\"traceId\":\"00-a88cfa6e646dd71561e1af7477b91cec-71a941c57a1bce9a-01\"}. status code returned: 500" app_id=checkout instance=MD053 scope=dapr.runtime type=log ver=1.9.6

## Update
Retries are currently working, failed message not put on dead letter queue topic