# C# Notification example

This is a simple example to show how notifications could be handled via SignalWire on C#.

## Examples

`dotnet run -- --mode sms --to +14043287999 --from +14043287000 --message "Welcome to SignalWire"`

`dotnet run -- --mode text --to +14043287999 --from +14043287000 --message "Welcome to SignalWire"`

## Set up configuration

```
export DEMO_SIGNALWIRE_PROJECT=<YOUR-PROJECT-ID>
export DEMO_SIGNALWIRE_TOKEN=<YOUR-PROJECT-TOKEN>
export DEMO_SIGNALWIRE_SPACE=<YOURSPACE>.signalwire.com
```

## LAML bin used

This makes the LAML bin dynamic.

```
<?xml version="1.0" encoding="UTF-8"?>
<Response>
<Say>{{message}}</Say>
</Response>
```