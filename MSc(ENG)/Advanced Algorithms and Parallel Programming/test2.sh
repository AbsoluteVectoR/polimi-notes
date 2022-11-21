echo "Generating Advanced Algorithms and Parallel Programming PDF"
pandoc --resource-path=src:src/images './src/Advanced Algorithms and Parallel Programming.md' -o aapp.pdf
