//#include<stdio.h>
//#include<stdlib.h>
//#define MAX_REQUESTS 100
//#define MAX_CYLINDERS 1000
//
//int calculateHeadMovements(int initial, int* requests, int* headMovements, int numOfRequests) {
//    int totalCountHeadMovements = 0;
//
//    for (int i = 0; i < numOfRequests; i++)
//    {
//        headMovements[i] = abs(initial - requests[i]);
//        totalCountHeadMovements += headMovements[i];
//        initial = requests[i];
//    }
//
//    return totalCountHeadMovements;
//}
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
//int getNumberRequestsFromUser() {
//    int numberOfRequests;
//    printf("Enter the number of requests\n");
//    scanf_s("%d", &numberOfRequests);
//    return numberOfRequests;
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
//int getInitialHeadPosition() {
//    int initial;
//    printf("Enter initial head position\n");
//    scanf_s("%d", &initial);
//    return initial;
//}
//
//int main()
//{
//    int requests[MAX_REQUESTS], headMovements[MAX_REQUESTS];
//    int numberOfRequests, initial, totalCountHeadMovements = 0;
//
//    numberOfRequests = getNumberRequestsFromUser();
//    getRequestsFromUser(requests, numberOfRequests);
//    initial = getInitialHeadPosition();
//
//    totalCountHeadMovements = calculateHeadMovements(initial, requests, headMovements, numberOfRequests);
//
//    printPath(requests, numberOfRequests);
//    printHeadMovements(headMovements, numberOfRequests);
//    printf("\nTotal head movement is %d", totalCountHeadMovements);
//    return 0;
//}