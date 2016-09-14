# StringBuilderTemporary
Read this in other languages: [English](README.md), 日本語<br />

<pre>
C#では、string同士の足し算だと temporaryでメモリを大量に確保されるため、
System.Text.StringBufferの使用する方がパフォーマンス的にもメモリ的にも良いです。

ですが、既に出来上がってしまったものをイチイチ対応するのはとても大変です。
そこで、処理をまともにするコードを簡単に書けるためのクラスを今回用意しました


まず、利用するコードのトップで下記宣言をします。
------
using StrOpe = StringOperationUtil.OptimizedStringOperation;
------

そして、実際のソースを
----
string str = "aaa" + 20 + "bbbb"; 
　　↓
string str = StrOpe.i + "aaa" + 20 + "bbbb"; 
----
とすることで、処理が大分まともになります。

（内部的にはStringBuilderを利用します。
　operatorで + 演算子の上書き、暗黙的castを書くことで処理向上を行っております)

StrOpe.iは、同じオブジェクトを使いまわしますが、
そういうケースで使いたい場合は、StrOpe.Create()を代わりに使用してください。
</pre>

# Stringでの加算処理の重さテスト
<pre>
本プロジェクトには、Stringでの加算処理がドレだけ重いか確認するためにテストケースを用意しました。
testシーンを開いて実行してみてください。Profilerで確認するとドレほど重いかが確認できます。

画面をクリックすることで、今回の Sbt.iを入れるかどうかの変更が可能になっています。
画面中の「StrOpe Flag」がtrueになることで処理が格段に軽くなるのを確認できるかと思います。

 
コチラのテストでは、275 msec掛かっていた以下の処理が 3.5msecまで減ることを確認しております。
また、Managed memory確保量も 382.2MB -> 360B になるのを確認しました。
 
 var str = "TestD";
     for (int i = 0; i < 20000; ++i){
         str += "a";
 }
</pre>
