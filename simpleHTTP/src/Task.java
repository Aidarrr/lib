import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class PaginationHelper<I>
{
    int itemsPerPage;
    List<I> collection;
    List<List<I>> paged;
    /**
     * The constructor takes in an array of items and a integer indicating how many
     * items fit within a single page
     */
    public PaginationHelper(List<I> collection, int itemsPerPage)
    {
        this.collection = collection;
        this.itemsPerPage = itemsPerPage;
        /*List<I> temp = new ArrayList<I>();
        temp.add(collection[0]);
        I e = collection[0];
        for (int i = 0; i < collection.size(); i++)
        {
            temp.add(collection[i]);

        }*/
    }

    /**
     * returns the number of items within the entire collection
     */
    public int itemCount()
    {
        return collection.size();
    }

    /**
     * returns the number of pages
     */
    public int pageCount()
    {
        int page = 0;
        for (int i = 0; i < collection.size(); i++)
        {
            if((i + 1) % itemsPerPage == 0)
                page++;
        }
        if(collection.size() > 0)
            page++;
        return page;
    }

    /**
     * returns the number of items on the current page. page_index is zero based.
     * this method should return -1 for pageIndex values that are out of range
     */
    public int pageItemCount(int pageIndex)
    {
        if(pageIndex > pageCount() - 1 || pageIndex < 0)
        {
            return -1;
        }

        if(collection.size() < itemsPerPage)
            return collection.size();

        int amountElements = (pageIndex + 1) * itemsPerPage;
        int sub = amountElements - collection.size();
        if(sub > 0)
            return collection.size() - (pageIndex * itemsPerPage);
        else
            return  itemsPerPage;
    }

    /**
     * determines what page an item is on. Zero based indexes
     * this method should return -1 for itemIndex values that are out of range
     */
    public int pageIndex(int itemIndex) {
        if(itemIndex < 0 || itemIndex >= collection.size())
            return -1;
        return (itemIndex + 1) / itemsPerPage;
    }
}

public class Task
{
    public static void main(String[] args) {
        PaginationHelper<Character> helper = new PaginationHelper<Character>(Arrays.asList('a', 'b', 'c', 'd', 'a', 'b', 'c', 'd','a', 'b', 'c', 'd','c', 'd'), 10);
        int a = helper.pageItemCount(1);
    }
}

