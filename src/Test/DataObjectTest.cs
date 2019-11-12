using System;
using System.Collections;

using NUnit.Framework;

using Spring2.Core.DataObject;
using Spring2.Core.Types;

namespace Spring2.Core.Test {
    /// <summary>
    /// Test suite for data objects.
    /// </summary>
    [TestFixture]
    public class DataObjectTest {

	private static readonly StringType PROP1_BEFORE_CHANGE = StringType.Parse("before change");
	private static readonly StringType PROP1_AFTER_CHANGE = StringType.Parse("after change");
	private static readonly IdType ID_VALUE = new IdType(1);
	private static readonly StringType CONTAINED_PROP1_BEFORE_CHANGE = StringType.Parse("contained before change");
	private static readonly StringType CONTAINED_PROP1_AFTER_CHANGE =  StringType.Parse("contained aftger change");
	private static readonly StringType ARRAY_1_VALUE = StringType.Parse("Array #1");
	private static readonly StringType ARRAY_2_VALUE = StringType.Parse("Array #2");
	private static readonly StringType ARRAY_3_VALUE = StringType.Parse("Array #3");
	private static readonly StringType ARRAY_CHANGE_ATTEMPT = StringType.Parse("Shouldn't See");


	/// <summary>
	/// Test the Update method
	/// </summary>
	[Test]
	public void TestUpdate() {
	    TestData data = GetTestData();

	    TestData updateData = new TestData();
	    updateData.Prop1 = PROP1_AFTER_CHANGE;
	    updateData.DataObject1.Prop1 = CONTAINED_PROP1_AFTER_CHANGE;
	    Test2Data temp = new Test2Data();
	    temp.Prop1 = ARRAY_CHANGE_ATTEMPT;
	    updateData.TestCollection1.Add(temp);

	    data.Update(updateData);

	    Assert.IsTrue(data.Id.Equals(ID_VALUE), "Update - Id changed when shouldn't");
	    Assert.IsTrue(data.Prop1.Equals(PROP1_AFTER_CHANGE), "Property 1 in TestData did not change");
	    Assert.IsTrue(data.DataObject1.Prop1.Equals(CONTAINED_PROP1_AFTER_CHANGE), "Property 1 in Test2Data did not change");
	    IEnumerator il = data.TestCollection1.GetEnumerator();
	    Assert.IsTrue(il.MoveNext(), "First collection entry not found");
	    Assert.IsTrue(((Test2Data)(il.Current)).Prop1.Equals(ARRAY_1_VALUE), "First array value changed.");
	    Assert.IsTrue(il.MoveNext(), "Second collection entry not found");
	    Assert.IsTrue(((Test2Data)(il.Current)).Prop1.Equals(ARRAY_2_VALUE), "Second array value changed.");
	    Assert.IsTrue(il.MoveNext(), "Third collection entry not found");
	    Assert.IsTrue(((Test2Data)(il.Current)).Prop1.Equals(ARRAY_3_VALUE), "Third array value changed.");
	    Assert.IsTrue(!(il.MoveNext()), "added 4th collection entry.");
	}

	/// <summary>
	/// Test the Equals method
	/// </summary>
	[Test]
	public void TestEquals() {
	    TestData data = GetTestData();
	    Assert.IsTrue(data.Equals(data), "Object does not equal itself");
	    TestData data2 = GetTestData();
	    Assert.IsTrue(data.Equals(data2), "Equal objects not equal");
	    data2.Prop1 = PROP1_AFTER_CHANGE;
	    Assert.IsTrue(!data.Equals(data2), "Equals doesn't notice datatype in top level dataobject change");
	    data2.Prop1 = data.Prop1;
	    data2.DataObject1.Prop1 = CONTAINED_PROP1_AFTER_CHANGE;
	    Assert.IsTrue(!data.Equals(data2), "Equals doesn't notice datatype in contained dataobject change");
	    data2.DataObject1.Prop1 = data.DataObject1.Prop1;
	    IEnumerator il = data2.TestCollection1.GetEnumerator();
	    il.MoveNext();
	    il.MoveNext();
	    ((Test2Data)(il.Current)).Prop1 = ARRAY_CHANGE_ATTEMPT;
	    Assert.IsTrue(!data.Equals(data2), "Equals doesn't notice datatype in list object change");
	}

	/// <summary>
	/// Test the Compare method
	/// </summary>
	[Test]
	public void TestCompare() {
	    TestData data = GetTestData();
	    DataObjectCompareList list = data.Compare(data);
	    Assert.IsTrue(list.Count == 0, "Object does not equal itself\n" + list.ToString());
	    TestData data2 = GetTestData();
	    list = data.Compare(data2);
	    Assert.IsTrue(list.Count == 0, "Equal objects not equal");

	    data2.Prop1 = PROP1_AFTER_CHANGE;
	    list = data.Compare(data2);
	    Assert.IsTrue(list.Count != 0, "Only change in one top level object - saw none\n" + list.ToString());
	    Assert.IsTrue(list.Count == 1, "Only change in one top level object - saw more\n" + list.ToString());
	    Assert.IsTrue(list[0].PropertyName.Equals("TestData.Prop1")	&& 
			  list[0].Value1.Equals(PROP1_BEFORE_CHANGE) && 
                          list[0].Value2.Equals(PROP1_AFTER_CHANGE),
			  "One Change in top level object - properties incorrect\n" + list.ToString());

	    data2.Prop1 = data.Prop1;
	    data2.DataObject1.Prop1 = CONTAINED_PROP1_AFTER_CHANGE;
	    list = data.Compare(data2);
	    Assert.IsTrue(list.Count != 0, "Only change in one contained object - saw none\n" + list.ToString());
	    Assert.IsTrue(list.Count == 1, "Only change in one contained object - saw more\n" + list.ToString());
	    Assert.IsTrue(list[0].PropertyName.Equals("TestData.DataObject1.Prop1") && 
			  list[0].Value1.Equals(CONTAINED_PROP1_BEFORE_CHANGE) && 
			  list[0].Value2.Equals(CONTAINED_PROP1_AFTER_CHANGE),
			  "One Change in contained object - properties incorrect\n" + list.ToString());

	    data2.DataObject1.Prop1 = data.DataObject1.Prop1;
	    ((Test2Data)(data2.TestCollection1[1])).Prop1 = ARRAY_CHANGE_ATTEMPT;
	    list = data.Compare(data2);
	    Assert.IsTrue(list.Count != 0, "Only change in one array object - saw none\n" + list.ToString());
	    Assert.IsTrue(list.Count == 1, "Only change in one array object - saw more\n" + list.ToString());
	    Assert.IsTrue(list[0].PropertyName.Equals("TestData.TestCollection1[1].Prop1") && 
			  list[0].Value1.Equals(ARRAY_2_VALUE) && 
			  list[0].Value2.Equals(ARRAY_CHANGE_ATTEMPT),
			  "One Change in array object - properties incorrect\n" + list.ToString());

	    ((Test2Data)(data2.TestCollection1[1])).Prop1 = 
		((Test2Data)(data.TestCollection1[1])).Prop1;
	    data2.Prop1 = PROP1_AFTER_CHANGE;
	    data2.DataObject1.Prop1 = CONTAINED_PROP1_AFTER_CHANGE;
	    ((Test2Data)(data2.TestCollection1[1])).Prop1 = ARRAY_CHANGE_ATTEMPT;
	    list = data.Compare(data2);
	    Assert.IsTrue(list.Count == 3, "Expected 3 changes did not get them\n" + list.ToString());
	    bool foundTop = false;
	    bool foundContained = false;
	    bool foundArray = false;
	    for (int i=0;i<3;i++) {
		if (list[i].PropertyName.Equals("TestData.Prop1")
		    && list[i].Value1.Equals(PROP1_BEFORE_CHANGE) 
		    && list[i].Value2.Equals(PROP1_AFTER_CHANGE)) {
		    foundTop = true;
		}
		if (list[i].PropertyName.Equals("TestData.TestCollection1[1].Prop1")
		    && list[i].Value1.Equals(ARRAY_2_VALUE) 
		    && list[i].Value2.Equals(ARRAY_CHANGE_ATTEMPT)) {
		    foundArray = true;
		}
		if (list[i].PropertyName.Equals("TestData.DataObject1.Prop1")
		    && list[i].Value1.Equals(CONTAINED_PROP1_BEFORE_CHANGE) 
		    && list[i].Value2.Equals(CONTAINED_PROP1_AFTER_CHANGE)) {
		    foundContained = true;
		}
	    }
	    
	    Assert.IsTrue(foundTop, "Top level change in multi change not found\n" + list.ToString());
	    Assert.IsTrue(foundContained, "Contained change in multi change not found\n" + list.ToString());
	    Assert.IsTrue(foundArray, "Array change in multi change not found\n" + list.ToString());

	    data = GetTestData();
	    data2 = GetTestData();
	    data.Prop1 = StringType.DEFAULT;
	    data2.Prop1 = StringType.UNSET;
	    list = data.Compare(data2);
	    Assert.IsTrue(list.Count != 0, "Default Matched Unset on COMPARE_ALL\n" + list.ToString());

	    list = data.Compare(data2, DataObjectCompareOptionEnum.DEFAULT_EQUALS_UNSET);
	    Assert.IsTrue(list.Count == 0, "Default didn't match Unset on DEFAULT_EQUALS_UNSET\n" + list.ToString());

	    data2.Prop1 = PROP1_BEFORE_CHANGE;
	    list = data.Compare(data2, DataObjectCompareOptionEnum.IGNORE_DEFAULT);
	    Assert.IsTrue(list.Count == 0, "Default didn't match value on IgnoreDefault\n" + list.ToString());
	}

	/// <summary>
	/// Get a generic test data item with values set.
	/// </summary>
	/// <returns>Item to test against.</returns>
	private TestData GetTestData() {
	    TestData data = new TestData();
	    data.Id = new IdType(1);
	    data.Prop1 = PROP1_BEFORE_CHANGE;
	    
	    Test2Data temp = new Test2Data();
	    temp.Prop1 = ARRAY_1_VALUE;
	    data.TestCollection1.Add(temp);
	    temp = new Test2Data();
	    temp.Prop1 = ARRAY_2_VALUE;
	    data.TestCollection1.Add(temp);
	    temp = new Test2Data();
	    temp.Prop1 = ARRAY_3_VALUE;
	    data.TestCollection1.Add(temp);

	    data.DataObject1.Prop1 = CONTAINED_PROP1_BEFORE_CHANGE;

	    return data;
	}
    }
}
