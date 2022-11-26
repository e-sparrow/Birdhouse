# Serialization

It's part of repository contains serialization logic.

## How to use

If you need to serialize one instance to one file, you should use SerializationController. 

Best way to create serialization controller if you have path and method you need to use:
```c#
var method = ESerilizationMethod.Binary; // It can be any type you want
var fileName = @$"example.data";
var path = Path.Combine(Application.persistentDataPath, fileName);

var controller = SerializationHelper.GetDefaultSerializationController(method, path);
...
```

Now, when you created the serialization controller, you should use it to serialize your data:
```c#
...
var data = new ExampleData(); // Don't care about this class, it's a just example

// First way
controller.Serialize(data);

// Second way, similar to previous, but inversed by extension method
data.Serialize(controller);
```
Obviously, serialization controller can serialize object. How to deserialize it?

Try something like (method or task where you use it should be async):
```c#
// First way
if (controller.IsExist()) // You can check is file controller should to deserialize exist or not!
{
    var deserializedObject = await controller.Deserialize<ExampleData>(); 
    // Put your logic where you use deserialized object here
}

// Second way, similar to previous, but a bit changed to be more readable and handy
if (controller.TryDeserialize(out var deserializedObject))
{
    // Put your logic where you use deserialized object here
}
```

## Warnings

Json and Xml serialization methods can't be used to create serialization storages and can't serialize some data types like dictionaries (it's a obvious reason why it can't be used in storages).