# StringBuilderTemporary
Read this in other languages: English, [日本語](README.ja.md)<br />

<pre>
Concatenating many strings allocates much teporary memory in Managed Heap.
It is better to use "System.Text.StringBuffer".

But it was heavy task to fix it,if you have already written many code.
So we prepare this to fix that case easily.


To use this , you put this on the top of code.
------
using StrOpe = StringOperationUtil.OptimizedStringOperation;
------

----
before code
  string str = "aaa" + 20 + "bbbb"; 

after code 
  string str = StrOpe.i + "aaa" + 20 + "bbbb"; 
----
You only have to put "StrOpe.i" before string concat operation.

( Internal , "StrOpe.i" uses StringBuilder class.
  We implement it by overriding "operator +" and implicit cast.)


"StrOpe.i" reuse same object.
You can use "StrOpe.small" / "StrOpe.medium" / "StrOpe.large" instead of "StrOpe.i". 
These are creating instance. So it is "Thread safe".</pre>

# Test case
<pre>
We prepared test case.

Open "test.scene" and run.
To click screen , you can change using "StrOpe.i" or not.
If "sbt Flag true" comes on screen , program runs much more faster.


This is the result of our test.
 - Execute Time   : 275 msec => 3.5msec
 - Managed memory : 382.2MB -> 360B 

--- excute code ---
 string str = "TestD";
     for (int i = 0; i < 20000; ++i){
         str += "a";
 }
------------------
</pre>
