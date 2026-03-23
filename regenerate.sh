#!/bin/bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
GENERATOR_DIR="$SCRIPT_DIR/../generator"

if [ ! -d "$GENERATOR_DIR" ]; then
  echo "Error: Generator not found at $GENERATOR_DIR"
  echo "Clone it: git clone https://github.com/apigen-dotnet/generator.git $GENERATOR_DIR"
  exit 1
fi

echo "Regenerating from specs..."
dotnet run --project "$GENERATOR_DIR/src/Apigen.Generator/Apigen.Generator.csproj" -- --config "$SCRIPT_DIR/specs/vikunja.toml"
echo "Done!"
