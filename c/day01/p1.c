#include <stdio.h>

int main(){

  char buffer[16];
  long cal_sums[255];
  // Zero out array
  for(unsigned long i = 0; i < sizeof(cal_sums)/sizeof(long);i++) cal_sums[i] = 0;
  int cal_it = 0;

  FILE* f = fopen("input", "r");
  if(f == NULL) perror("Error opening file");

  long acc = 0;

  char* result = fgets(buffer, 16, f);
  while(result != NULL){
    // If empty line, flush acc
    if(buffer[0] == '\n') {
      cal_sums[cal_it++] = acc;
      acc = 0;
    }
    else {
      long cal = 0;
      for(int i = 0; buffer[i] != '\n'; i++){
        cal *= 10;
        cal += buffer[i] - 48;
      }
      acc += cal;
    }
    // Get next line
    // Zero out buffer
    for(int i = 0; i != sizeof(buffer); i++) buffer[i] = 0;
    result = fgets(buffer, 16, f);
  }

  int cal_end = cal_it;

  // Peform 3 iterations of linear
  // places top 3 values in decending order in cal_sums
  for(int i = 1; i < 4; i++){
    while(cal_it >= i) {
      if(cal_sums[cal_it] > cal_sums[cal_it - 1]){
        long temp = cal_sums[cal_it];
        cal_sums[cal_it] = cal_sums[cal_it - 1];
        cal_sums[cal_it - 1] = temp;
      }
      cal_it--;
    }
    cal_it = cal_end;
  }

  printf("Maximum: %ld\n", cal_sums[0]);
  printf("Total of top 3: %ld\n", cal_sums[0] + cal_sums[1] + cal_sums[2]);
  return 0;
}
