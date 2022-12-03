package main

import "fmt"
import "io/ioutil"
import "bytes"

func main() {
    var bit_set = [160]byte{0}
    input, err := ioutil.ReadFile("input")

    if err != nil {
        panic("Error opening files")
    }

    lines := bytes.Split(input, []byte("\n"));

    var sum = 0;

    for team := 0; team < len(lines) / 3; team += 1{
        line1 := lines[team*3]
        line2 := lines[team*3 + 1]
        line3 := lines[team*3 + 2]

        for i := 0; i < len(line1); i++ {
            bit_set[line1[i]] = 1;
        }
        for i := 0; i < len(line2); i++ {
            if bit_set[line2[i]] == 1 {
                bit_set[line2[i]] = 2;
            }
        }
        for i := 0; i < len(line3); i++ {
            if bit_set[line3[i]] == 2 {
                sum += int(score(line3[i]))
                break;
            }
        }
        bit_set = [160]byte {0}
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