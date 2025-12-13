# Migration Plan: Upgrade to Java 21

Session ID: 2a93d22f-3aa5-4af8-9156-e724ce826b97
Created: 2025-12-12 19:31:25

## Overview
- Goal: Upgrade project runtime to Java 21 (LTS)
- Build tool: Maven (detected via pom.xml)
- Project path: c:/Users/HP/Desktop/java-consoles/java-consoles

## Steps
1. Create branch `appmod/java-migration-20251212193125` and stash uncommitted changes (policy: Always Stash)
2. Ensure JDK 21 is installed and set JAVA_HOME accordingly
3. Update `pom.xml` to set `maven.compiler.source`/`target` and `java.version` to 21
4. Update `maven-compiler-plugin` config to 21
5. Build and run tests, fix issues iteratively (CVE/build/consistency/tests/completeness)
6. Commit changes and create migration summary

## Build environment
- Target JDK: 21 (LTS)
- Build tool: Maven (use `./mvnw` if wrapper is present; otherwise use system Maven)

## Files to update
- pom.xml: set java.version to 21, adjust maven-compiler-plugin, check dependencies

## Notes
- Use `appmod-*` tools for build, tests, and version control operations as required
- Follow validation & fix loop until all stages pass
