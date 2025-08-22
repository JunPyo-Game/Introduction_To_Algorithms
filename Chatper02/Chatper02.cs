namespace Chatper02;

public class Pratice
{

    /*
        루프의 불변성

        초기화 - 아직 아무런 값도 더하지 않았으므로 0이다.
        유지 - 부분 배열 array[0:i]의 요소의 합을 가진다.
        종료 - 모든 요소의 합을 가진다.
    */
    static public int SumArray(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    /*
        [루프의 불변성]

        초기화 - 아직 아무런 값도 반환하지 않았다.
        유지 - 부분 배열 array[0:i]에서 x와 같은 값이 없다면 반환값이 결정되지 않았다.
        종료 - x와 같은 값을 찾았다면 인덱스를 반환하고 발견하지 못하고 순회를 마치면 null을 반환한다.

        [시간 복잡도]
        평균적인 경우 배열의 중간에 찾을 것을 기대할 수 있다. 
        즉, n/2의 시간이 걸릴 것을 예상할 수 있다.

        최악의 경우 찾지 못하거나 마지막 요소일 수 있다.
        즉, n의 시간이 걸릴 것을 예상할 수 있다.

        시간복잡도는 평균적인 경우, 최악의 경우 동일하게 O(n)이다.
    */
    static public int? SearchNumber(int[] array, int x)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == x)
                return i;
        }

        return null;
    }

    static public int[] AddBinaryIntergers(int[] A, int[] B)
    {
        int[] C = new int[A.Length + 1];

        int carry = 0;
        for (int i = 0; i < A.Length; i++)
        {
            int sum = A[i] + B[i] + carry;
            C[i] = sum % 2;
            carry = sum / 2;
        }

        C[A.Length] = carry;

        return C;
    }

    static public int BinarySearch(int[] array, int target)
    {
        return BinarySearchHelper(array, target, 0, array.Length - 1);
    }

    static public int BinarySearch2(int[] array, int target)
    {
        int start = 0;
        int end = array.Length - 1;

        while (start <= end)
        {
            int middle = (start + end) / 2;

            if (array[middle] == target)
                return middle;

            if (array[middle] < target)
                start = middle + 1;
            else
                end = middle - 1;
        }

        return -1;
    }

    static public int BinarySearchHelper(int[] array, int target, int start, int end)
    {
        if (start > end)
            return -1;

        int middle = (start + end) / 2;

        if (array[middle] == target)
            return middle;

        else if (array[middle] > target)
            return BinarySearchHelper(array, target, start, middle - 1);

        else
            return BinarySearchHelper(array, target, middle + 1, end);
    }

    static public bool HasPairWithSum(int[] array, int x)
    {
        Array.Sort(array);

        int start = 0;
        int end = array.Length - 1;
        
        while (start < end)
        {
            int sum = array[start] + array[end];

            if (sum == x)
                return true;

            else if (sum < x)
                start++;

            else
                end--;
        }

        return false;
    }
}
