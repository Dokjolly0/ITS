<?php 
function maggiore($n1, $n2){
    if(n1 > n2)return n1;
    else return n2;
}
$M = maggiore($_POST['input1'], $_POST['input2']);
// print('Il numero maggiore è: ' + $M);
print(`Il numero maggiore è: $M`);
?>