<!--title:Document Id's-->

Besides being serializable, Marten's only other requirement for a .Net type to be a document is the existence of an identifier field or property that Marten can use as the primary key for the document type. The `Id` can be either a public field or property, and the name must be either `id` or `Id`. As of this time, Marten supports these `Id` types:

1. `String`. It might be valuable to use a [natural key](https://en.wikipedia.org/wiki/Natural_key) as the identifier, especially if it is valuable within the 
   <[linkto:documentation/documents/identitymap;title=Identity Map]> feature of Marten Db. In this case, the user will 
   be responsible for supplying the identifier.
1. `Guid`. If the id is a Guid, Marten will assign a new value for you when you persist the document for the first time if the id is empty. 
   _And for the record, it's pronounced "gwid"_.
1. `Int` or `Long`. As of right now, Marten uses a [HiLo generator](http://stackoverflow.com/questions/282099/whats-the-hi-lo-algorithm) approach to assigning numeric identifiers by document type. 
   Marten may support Postgresql sequences or star-based algorithms as later alternatives.

You can see some example id usages below:

<[sample:id_samples]>

## Hilo Sequences

The _Hilo_ sequence generation can be customized with either global defaults or document type specific overrides. By default, the Hilo sequence generation in Marten increments by 1 and uses a "maximum lo" number of 1000.

To set different global defaults, use the `StoreOptions.HiloSequenceDefaults` property like this sample:

<[sample:configuring-global-hilo-defaults]>

To override the Hilo configuration for a specific document type, you can decorate the document type with the `[HiloSequence]` attribute
as in this example:

<[sample:overriding-hilo-with-attribute]>

You can also use the `MartenRegistry` fluent interface to override the Hilo configuration for a document type as in this example:

<[sample:overriding-hilo-with-marten-registry]>


