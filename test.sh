#!/usr/bin/bash

single=http://192.168.31.252:5435/api/careers/0f32e0c6-bd0f-4eb0-8730-53711b05862f
load_balancer=http://192.168.31.252:8123/api/careers/0f32e0c6-bd0f-4eb0-8730-53711b05862f
amount_request=30000
concurrency=2500

single_output=$(mktemp)
load_balancer_output=$(mktemp)

ulimit -n 65535


ab -n $amount_request -c $concurrency $single > $single_output
ab -n $amount_request -c $concurrency $load_balancer > $load_balancer_output

diff -y $single_output $load_balancer_output
