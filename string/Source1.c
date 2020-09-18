//#include <stdio.h>
//#include "sthread.h"
//
//static void go(int n);
//
//#define NTHREADS 10
//static sthread_t threads[NTHREADS];
//
//int main(int argc, char** argv)
//{
//	int ii;
//
//	for (ii = 0; ii < NTHREADS; ii++)
//	{
//		pthread_create(&(threads[ii]), &go, ii);
//	}
//
//	for (ii = 0; ii < NTHREADS; ii++)
//	{
//		long ret = pthread_join(threads[ii]);
//		printf("Thread %d returned %ld\n", ii, ret);
//	}
//
//	printf("Main thread done.\n");
//	return 0;
//}
//
//void go(int n)
//{
//	printf("Hello from thread %d\n", n);
//	pthread_exit(100 + n);
//}