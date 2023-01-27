echo "Generating PDF for Advanced Algorithms and Parallel Programming"
echo $(pandoc --resource-path=src:src/images src/*.md -o aapp.pdf -f markdown-implicit_figures)
