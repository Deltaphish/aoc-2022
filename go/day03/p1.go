package main

import "fmt"
import "io/ioutil"
import "bytes"

func main() {
    var bit_set = [160]bool{false}
    input, err := ioutil.ReadFile("input")

    if err != nil {
        panic("Error opening files")
    }

    lines := bytes.Split(input, []byte("\n"));

    var sum = 0;

    for s := range lines{
        line := lines[s]
        for i := 0; i < len(line)/2; i++ {
            bit_set[line[i]] = true;
        }
        for i := len(line)/2; i < len(line);i++ {
            if bit_set[line[i]] == true {
                sum += int(score(line[i]))
                fmt.Printf("Found %c\n", line[i]);
                break;
            }
        }
        bit_set = [160]bool {false}
    }
    fmt.Printf("%d",sum);
    return
}

func score(a byte) byte {
    if a >='a' && a <= 'z'{
        return a - 97 + 1
    }
    if a >= 'A' && a <='Z' {
        return a - 65 + 27
    }
    panic("WHAAA")
}