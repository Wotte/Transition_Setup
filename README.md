# Transitions_setup
<b>Description</b><br>

Transitions_setup is a application that help you import/export transitions from Another Hour Another Planet.<br>

<b>Export</b><br>

Just After export your .oxz file through EditOneLife.exe :<br>

-Open the .oxz file in the application (on the left)<br>
-Befor click export make sure that you are exporting the last objects in the list and not missing one ( witch could cause problem )<br>
That will create a .trt file with all the transitions who have a reference too <br>

<b>Import</b><br>

in order :<br>
-Put .trt and .oxz file into "import_add" <br>
-Run EditOneLife.exe<br>
-Close after the load are done<br>
-Open the .trt file in the application (on the right)<br>
-click import<br>

<b>Important</b><br>
Import only work when you import new Objects, if you try import the .trt file of a mod after you import an other mod with a .oxz throught EditOneLife.exe that wont works <br>
```diff
+ Good way : modA.oxz => modA.trt => modB.oxz => modB.trt

- Wrong way : modA.oxz => modB.oxz => modA.trt => modB.trt
```

In any case do it in a diferent game file to be sure to not ensure the main game file.
