<p align="center">
  <img width="300" height="332" src="https://github.com/kateChrome/homeworkCsharp/blob/master/img/logoSpbu.png">
</p>

# SPBU homework

Here's homework on programming and materials from programming lessons.

## Navigation menu

[SPBU homework](https://github.com/kateChrome/homeworkCoctothorpe) | 
----------- |
[Homework plan](https://github.com/kateChrome/homeworkCoctothorpe#homework-plan)
[Homework №1](https://github.com/kateChrome/homeworkCoctothorpe#homework-1) |
[Homework №2](https://github.com/kateChrome/homeworkCoctothorpe#homework-2) |
[Homework №3](https://github.com/kateChrome/homeworkCoctothorpe#homework-3) |
[Homework №4](https://github.com/kateChrome/homeworkCoctothorpe#homework-4) |

## Homework plan

<p align="center">
<img src="http://yuml.me/diagram/scruffy/class/[note: Homework plan{bg:green}], [Homework number], [Homework number]-> [materail from lesson], [Homework number]->[list of tasks and their solutions (optional)], [list of tasks and their solutions (optional)]->[task №1], [task №1]-.->[solution №1], [list of tasks and their solutions (optional)]->[task №2], [list of tasks and their solutions (optional)]->[task №3], [task №3]-.->[solution №3]" >
</p>

## Homework №1 

>[material from lesson](https://github.com/kateChrome/homeworkCoctothorpe/tree/master/data/lesson1)

1. Посчитать факториал. [solution](https://github.com/kateChrome/homeworkCsharp/tree/master/hw1/hw1.1)

2. Посчитать числа Фибоначчи. [solution](https://github.com/kateChrome/homeworkCsharp/tree/master/hw1/hw1.2)

3. Отсортировать массив какой-либо из сортировок. [solution](https://github.com/kateChrome/homeworkCsharp/tree/master/hw1/hw1.3)

4. Дан массив размерностью N x N, N - нечетное число. Вывести элементы массива при обходе его по спирали, начиная с центра. [solution](https://github.com/kateChrome/homeworkCsharp/tree/master/hw1/hw1.4)

5. Отсортировать столбцы матрицы по первым элементам. [solution](https://github.com/kateChrome/homeworkCsharp/tree/master/hw1/hw1.5)

## Homework №2 

>[material from lesson](https://github.com/kateChrome/homeworkCoctothorpe/tree/master/data/lesson2)

1. Написать связный список в виде класса. От списка хочется:
    - Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом.
    - Узнавать размер, проверять на пустоту.
    - Получать или устанавливать значение элемента по позиции, задаваемой целым числом. [solution](https://github.com/kateChrome/homeworkCOctothorpe/tree/master/hw2/hw2.1)

2. Написать хеш-таблицу в виде класса с использованием класса-списка из первой задачи. Должно быть можно добавлять значение в хеш-таблицу, удалять и проверять на принадлежность. [solution](https://github.com/kateChrome/homeworkCOctothorpe/tree/master/hw2/hw2.2)

3. Реализовать стековый калькулятор (класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). Строка уже дана в обратной польской записи (например, 1 2 3 + *). Стек реализовать двумя способами (например, массивом или списком) в двух разных классах на основе одного интерфейса. Стековый калькулятор должен знать только про интерфейс стека. В Main надо спросить у пользователя, какой из вариантов стека он хочет, в зависимости от выбора создаётся объект одной из двух реализаций и передаётся калькулятору. [solution](https://github.com/kateChrome/homeworkCOctothorpe/tree/master/hw2/hw2.3)

## Homework №3

>[material from lesson](https://github.com/kateChrome/homeworkCoctothorpe/tree/master/data/lesson3)

1. Написать юнит-тесты к задаче 3 из предыдущего задания.[solution](https://github.com/kateChrome/homeworkCOctothorpe/tree/master/hw2/hw3.1)

2. Модифицировать хеш-таблицу из задачи 2 предыдущей работы так, чтобы хеш-функцию можно было менять в зависимости от выбора пользователя, причём хеш-функцию должно быть можно передавать из использующего хеш-таблицу кода в виде объекта некоторого класса, реализующего некоторый интерфейс. Юнит-тесты и коментарии в формате XML Documentation обязательны.

## Homework №4

>[material from lesson](https://github.com/kateChrome/homeworkCoctothorpe/tree/master/data/lesson4)

1. Решить задачу о вычислении выражения по дереву разбора из прошлого семестра. Реализовать иерархию классов, описывающих дерево разбора, используя их, реализовать класс, вычисляющий значение выражения по дереву. Классы, представляющие операнды и операторы, должны сами уметь себя вычислять и печатать.

**Исходное условие:**

>По дереву разбора арифметического выражения вычислить его значение. Дерево разбора хранится в файле в виде (<операция> <операнд1> <операнд2>), где <операнд1> и <операнд2> сами могут быть деревьями, либо числами. Например, выражение (1 + 1) * 2 представляется в виде (* (+ 1 1) 2). Должны поддерживаться операции +, -, *, / и целые числа в качестве аргументов. Требуется построить дерево в явном виде, распечатать его (не обязательно так же, как в файле), и посчитать значение выражения обходом дерева. Может быть полезна функция ungetc (если не '(', возвращаем символ в поток и читаем число fscanf-ом). Можно считать, что входной файл корректен. Пример - по входному файлу (* (+ 1 1) 2) может печататься ( * ( + 1 1 ) 2 ) и выводиться 4.

2. Унаследовавшись от класса список, реализовать класс UniqueList, который не содержит повторяющихся значений. Реализовать классы исключений, которые генерируются при попытке добавления в такой список уже существующего или при попытке удаления несуществующего элемента.

