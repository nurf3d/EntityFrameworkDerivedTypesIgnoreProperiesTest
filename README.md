# EntityFrameworkDerivedTypesIgnoreProperiesTest
Testing ignore Property for derived Types

### Inheritance Chain:

```
public abstract class BaseEntity
{
    [Key]
    public int ID { get; set; }

    [Timestamp]
    public byte[] Rowversion { get; set; }

    public State State { get; set; }
}

[Table("Events")]
public abstract class Event : BaseEntity
{
    public int PersonID { get; set; }

    public string EventName { get; set; }

    public virtual Person Person { get; set; }
}

public class DerivedEvent1 : Event
{
    public bool IsDerivedEvent1 { get; set; }
}

public class DerivedEvent2 : Event
{
    public bool IsDerivedEvent2 { get; set; }
}
```


### Attributes

When using the **[NotMappedAttribute]** the State-propery gets ignored for all types correctly and the migration runs fine, 
but this also removes the property from the odata-api, which we dont want.

Since we need the state property within the odata-api we are not using the **[NotMappedAttribute]**, but the fluent configuration.

### FluentConfiguration

`modelBuilder.Types<BaseEntity>().Configure(clazz => clazz.Ignore(prop => prop.State));`

`add-migration Initial -Force`

_You cannot use Ignore method on the property 'State' on type 'EntityFrameworkIgnoreProperty.Models.DerivedEvent1' because this type inherits from the type 'EntityFrameworkIgnoreProperty.Models.BaseEntity' where this property is mapped. To exclude this property from your model, use NotMappedAttribute or Ignore method on the base type._
