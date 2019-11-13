using System;

namespace Spring2.Core.Message {
    /// <summary>
    /// Summary description for ResourceKey.
    /// </summary>
    public class ResourceKey {
	private String context;
	private String field;
	private Int32 identity;


	public String Context{
	    get{return context;}
	    set{context = value;}
	}

	public String Field{
	    get{return field;}
	    set{field = value;}
	}

	public Int32 Identity{
	    get{return identity;}
	    set{identity = value;}
	}


	public ResourceKey(String newContext, String newField, Int32 newIdentity) {
	    context = newContext;
	    field = newField;
	    identity = newIdentity;
	}

	public ResourceKey(String newContext, String newField) {
	    context = newContext;
	    field = newField;
	}
	    
	
    }
}
