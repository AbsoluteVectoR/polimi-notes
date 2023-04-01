echo "Generating PDF for Computing Infrastructures"
echo $(pandoc --resource-path=src:src/images src/*.md -o computing.pdf -f markdown-implicit_figures)
