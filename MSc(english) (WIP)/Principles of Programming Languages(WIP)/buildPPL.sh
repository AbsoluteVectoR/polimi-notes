echo "Generating PDF for Principles of Programming Languages"
echo $(pandoc --resource-path=src:src/images src/*.md -o ppl.pdf -f markdown-implicit_figures)
