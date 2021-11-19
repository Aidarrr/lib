#include<stdio.h>
#include<stdlib.h>
#define MAX_REQUESTS 100
#define MAX_CYLINDERS 1000

int* moveHeadToLeft(int initial, int* path, int* headMovements, int* cylinders, int pos) {
    for (int i = initial; i >= 0; i--)
    {
        if (cylinders[i] == 1) {
            path[pos] = i;
            headMovements[pos] = initial - i;
            pos++;
            initial = i;
            cylinders[i] = 0;
        }
    }

    int posAndInitial[2];
    posAndInitial[0] = pos;
    posAndInitial[1] = initial;

    return posAndInitial;
}

int* moveHeadToRight(int initial, int* path, int* headMovements, int* cylinders, int pos) {
    for (int i = initial; i < MAX_CYLINDERS; i++)
    {
        if (cylinders[i] == 1) {
            path[pos] = i;
            headMovements[pos] = i - initial;
            pos++;
            initial = i;
            cylinders[i] = 0;
        }
    }

    int posAndInitial[2];
    posAndInitial[0] = pos;
    posAndInitial[1] = initial;

    return posAndInitial;
}

void runElevatorAlg(int initDirection, int initial, int* path, int* headMovements, int* cylinders) {
    int pos = 0;

    if (initDirection == 0) {
        int* posAndInitial = moveHeadToLeft(initial, path, headMovements, cylinders, pos);
        moveHeadToRight(posAndInitial[1], path, headMovements, cylinders, posAndInitial[0]);
    }
    else if (initDirection == 1) {
        int* posAndInitial = moveHeadToRight(initial, path, headMovements, cylinders, pos);
        moveHeadToLeft(posAndInitial[1], path, headMovements, cylinders, posAndInitial[0]);
    }
}



int main()
{
    int cylinders[MAX_CYLINDERS], path[MAX_REQUESTS], headMovements[MAX_REQUESTS];
    int numberOfRequests, totalCountHeadMovements = 0, initial, initDirection;

    printf("Enter the number of requests\n");
    scanf_s("%d", &numberOfRequests);

    printf("Enter the Requests sequence\n");
    for (int i = 0; i < numberOfRequests; i++)
    {
        int requestCylinderNumber;
        scanf_s("%d", &requestCylinderNumber);
        cylinders[requestCylinderNumber] = 1; //if cylinder[i] == 1 there is request
    }

    printf("Enter initial head position\n");
    scanf_s("%d", &initial);

    printf("Enter initial direction (1 - up, 0 - down)\n");
    scanf_s("%d", &initDirection);
    
    runElevatorAlg(initDirection, initial, path, headMovements, cylinders);

    printf("\nHead path:\n");
    for (int i = 0; i < numberOfRequests - 1; i++)
    {
        printf("%d -> ", path[i]);
    }
    printf("%d\n", path[numberOfRequests - 1]);

    printf("\nHead movements count:\n");
    for (int i = 0; i < numberOfRequests - 1; i++)
    {
        printf("%d, ", headMovements[i]);
        totalCountHeadMovements += headMovements[i];
    }
    printf("%d\n", headMovements[numberOfRequests - 1]);
    totalCountHeadMovements += headMovements[numberOfRequests - 1];

    printf("\nTotal head movement is %d", totalCountHeadMovements);
    return 0;
}