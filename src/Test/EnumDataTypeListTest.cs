using System;

using Xunit;
using Spring2.Core.Types;
using Spring2.Core.DataObject;

namespace Spring2.Core.Test {

    /// <summary>
    /// Tests for EnumDataTypeList
    /// </summary>

    public class EnumDataTypeListTest {
	[Fact]
	public void EnumDataTypeListNameSorter() {
	    USStateCodeEnum.Options.Sort(new EnumDataTypeNameSorter());
	    Assert.Equal("AK", USStateCodeEnum.Options[0].Name);
	}

	[Fact]
	public void EnumDataTypeNameSorterDesc() {
	    USStateCodeEnum.Options.Sort(new EnumDataTypeNameSorterDesc());
	    Assert.Equal("WY", USStateCodeEnum.Options[0].Name);
	}

	[Fact]
	public void SortByNameMethod() {
	    USStateCodeEnum.Options.Sort(new EnumDataTypeNameSorterDesc());
	    USStateCodeEnum.Options.SortByName();
	    Assert.Equal("AK", USStateCodeEnum.Options[0].Name);
	}

	[Fact]
	public void SortByNameDescMethod() {
	    USStateCodeEnum.Options.SortByName();
	    USStateCodeEnum.Options.SortByNameDesc();
	    Assert.Equal("WY", USStateCodeEnum.Options[0].Name);
	}
    }
}
