var array = GenerateArray(11);
Console.WriteLine($"Исходный: {string.Join(" ",array)}");
var result = ShakerSortV2(array);
Console.WriteLine($"Результат: {string.Join(" ",result)}");

Console.WriteLine("See result");

static int[] GenerateArray(int size)
{
    var result = new int[size];
    for (var i = 0; i < size; i++)
    {
        result[i] = new Random().Next(100);
    }

    return result;
}

//Сортировка пузырьком
static int[] BubbleSort(int[] mas)
{
    for (var i = 0; i < mas.Length; i++) // mas.Length == n
    {
        for (var j = i + 1; j < mas.Length; j++)
        {
            if (mas[i] > mas[j])
            {
                (mas[i], mas[j]) = (mas[j], mas[i]);
            }                   
        }            
    }
    return mas;
}


//сортировка перемешиванием
static int[] ShakerSort(int[] array)
{
    for (var i = 0; i < array.Length / 2; i++)
    {
        var swapFlag = false;
        //проход слева направо
        for (var j = i; j < array.Length - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                swapFlag = true;
            }
        }

        //проход справа налево
        for (var j = array.Length - 2 - i; j > i; j--)
        {
            if (array[j - 1] > array[j])
            {
                (array[j - 1], array[j]) = (array[j], array[j - 1]);
                swapFlag = true;
            }
        }

        //если обменов не было выходим
        if (!swapFlag)
        {
            break;
        }
    }

    return array;
}

    
//метод для генерации следующего шага
static int GetNextStep(int s)
{
    s = s * 1000 / 1247;
    return s > 1 ? s : 1;
}

static int[] CombSort(int[] array)
{
    var arrayLength = array.Length;
    var currentStep = arrayLength - 1;
        
    while (currentStep > 1)
    {
        for (var i = 0; i + currentStep < array.Length; i++)
        {
            if (array[i] > array[i + currentStep])
            {
                (array[i], array[i + currentStep]) = (array[i + currentStep], array[i]);
            }
        }

        currentStep = GetNextStep(currentStep);
    }

    //сортировка пузырьком
    for (var i = 1; i < arrayLength; i++)
    {
        var swapFlag = false;
        for (var j = 0; j < arrayLength - i; j++)
        {
            if (array[j] > array[j + 1])
            {
                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                swapFlag = true;
            }
        }

        if (!swapFlag)
        {
            break;
        }
    }

    return array;
}


//сортировка вставками
static int[] InsertionSort(int[] array)
{
    for (var i = 1; i < array.Length; i++)
    {
        var key = array[i];
        var j = i;
        while (j >= 1 && array[j - 1] > key)
        {
            
            (array[j - 1], array[j]) = (array[j], array[j - 1]);
            j--;
        }

        array[j] = key;
    }

    return array;
}


static int[] ShellSort(int[] array)
{
    //расстояние между элементами, которые сравниваются
    var d = array.Length / 2;
    while (d >= 1)
    {
        for (var i = d; i < array.Length; i++)
        {
            var j = i;
            while (j >= d && array[j - d] > array[j])
            {
                
                (array[j - d], array[j]) = (array[j], array[j - d]);
                j -= d;
            }
        }

        d /= 2;
    }

    return array;
}


static int[] ShakerSortV2(int[] array)
{
    var begin = 0;
    var end = array.Length - 1;
    var rightDirection = true; 
    
    while (begin<=end)
    {
        if (rightDirection)
        {
            for (int i = begin; i < end; i++)
            {
                if (array[i]>array[i+1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }

            end -= 1;
        }
        else
        {
            for (int i = end; i > begin; i--)
            {
                if (array[i-1]>array[i])
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                }
            }

            begin += 1;
        }
        
        rightDirection = !rightDirection;
    }
    
    return array;
}

