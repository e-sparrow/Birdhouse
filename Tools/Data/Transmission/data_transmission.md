# Data Transmission
As you can see in some files like `DataTransmissionExtensions` 
some other instances like `ISerializationStorage` can be adapted 
to interfaces like `I(Async)DataTransmitter`. 

**Why?**

Because logic that interfaces implement can be used in a lot of cases like:
- Addressables
- Serialization
- Client-server logic
- ...

Now, you should understand how is usable. 

Beside use concrete implementations from this list, you can use interfaces used in this folder to keep it simple.