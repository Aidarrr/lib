//#include<stdio.h>
//#include<stdlib.h>
//#define MAX_REQUESTS 100
//#define UNREACHABLE_DISTANCE 1000
//
//void printPath(int* path, int numberOfRequests) {
//    printf("\nHead path:\n");
//    for (int i = 0; i < numberOfRequests - 1; i++)
//    {
//        printf("%d -> ", path[i]);
//    }
//    printf("%d\n", path[numberOfRequests - 1]);
//}
//
//void printHeadMovements(int* headMovements, int numberOfRequests) {
//    printf("\nHead movements count:\n");
//    for (int i = 0; i < numberOfRequests - 1; i++)
//    {
//        printf("%d, ", headMovements[i]);
//    }
//    printf("%d\n", headMovements[numberOfRequests - 1]);
//}
//
//void getRequestsFromUser(int* requests, int numberOfRequests) {
//    printf("Enter the Requests sequence\n");
//    for (int i = 0; i < numberOfRequests; i++)
//    {
//        scanf_s("%d", &requests[i]);
//    }
//}
//
//int runAlgorithm(int numberOfRequests, int* requests, int initial, int* path, int* headMovements) {
//    int totalCountHeadMovements = 0;
//
//    for (int i = 0; i < numberOfRequests; i++)
//    {
//        int min = UNREACHABLE_DISTANCE, distance, indexClosestCylinder;
//        for (int j = 0; j < numberOfRequests; j++)
//        {
//            distance = abs(requests[j] - initial);
//            if (distance < min)
//            {
//                min = distance;
//                indexClosestCylinder = j;
//            }
//        }
//
//        totalCountHeadMovements += min;
//        initial = requests[indexClosestCylinder];
//
//        path[i] = requests[indexClosestCylinder];
//        headMovements[i] = min;
//
//        requests[indexClosestCylinder] = UNREACHABLE_DISTANCE;
//    }
//
//    return totalCountHeadMovements;
//}
//
//int main()
//{
//    int requests[MAX_REQUESTS], path[MAX_REQUESTS], headMovements[MAX_REQUESTS];
//    int numberOfRequests, currentRequest = 0, totalCountHeadMovements = 0, initial;
//
//    printf("Enter the number of requests\n");
//    scanf_s("%d", &numberOfRequests);
//
//    getRequestsFromUser(requests, numberOfRequests);
//
//    printf("Enter initial head position\n");
//    scanf_s("%d", &initial);
//
//    totalCountHeadMovements = runAlgorithm(numberOfRequests, requests, initial, path, headMovements);
//
//    printPath(path, numberOfRequests);
//    printHeadMovements(headMovements, numberOfRequests);
//    printf("\nTotal head movement is %d", totalCountHeadMovements);
//    return 0;
//}