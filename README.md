# Комбинаторика
В библиотеке CombineLib реализованы функции перестановки, размещения и сочетания. Возможно использование многопоточности.  
  
- P(n) перестановки из n  
- A(n, m) размещения n по m  
- C(n, m) сочетания n по m  
- P(n, numThread) перестановки из n с numThread количеством потоков  
- A(n, m, numThread) размещения n по m с numThread количеством потоков  
- C(n, m, numThread) сочетания n по m с numThread количеством потоков  
  
#### Скорость алгоритма
В расчетах используется умножение с помощью дерева, что существенно ускоряет алгоритм  
На примере сочетания С(10<sup>5</sup>, m)  
- Нативный алгоритм предполагает вычисление трех факториалов и последующего их деления  
- Первая модификация позволяет считать только один полный и один неполный факториал  
- На основе первой модификации, во второй модификации выполняется умножение деревом  
  
Время выполнения (сек)  
|m|1|25*10<sup>3</sup>|50*10<sup>3</sup>|75*10<sup>3</sup>|10<sup>5</sup>|
|---|---|---|---|---|---|
|native|8|8|8|8|8|
|mod1|0|0.5|2|0.5|0|
|mod2|0|0.15|0.5|0.15|0|
