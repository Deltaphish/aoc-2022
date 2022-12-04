#!/usr/bin/env perl

use v5.36;

open(my $in, "<", "input") or die "Cant open file $!";

my $count = 0;
while (<$in>) {
    if(/(\d+)-(\d+),(\d+)-(\d+)/){
        if($1 >= $3 && $2 <= $4){
            $count += 1;
        }
        elsif($3 >= $1 && $4 <= $2){
            $count += 1;
        }
    }
}
print $count;
